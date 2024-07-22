using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MonthlyReprimand.Models.Request;
using MonthlyReprimand.Models.Response;
using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Entities;
using MonthlyReprimand.Data.Repositories;
using System.Data;

namespace MonthlyReprimand.Services
{
    /// <summary>
    /// Сервис сотрудника
    /// </summary>
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly PositionRepository _positionRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeUnitOfWork _employeeUnitOfWork;

        public EmployeeService(EmployeeRepository employeeRepository, PositionRepository positionRepository, 
            IMapper mapper, EmployeeUnitOfWork employeeUnitOfWork)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _mapper = mapper;
            _employeeUnitOfWork=employeeUnitOfWork;
        }

        /// <summary>
        /// Получение всех сотрудников
        /// </summary>
        /// <param name="getEmployeesRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task<IEnumerable<GetEmployeesResponse>> GetAllEmployeesAsync(GetEmployeesRequest getEmployeesRequest)
        {
            List<GetEmployeesResponse> result;
            if (getEmployeesRequest.PositionName != null)
            {

                var positionEntity = await _positionRepository.GetPositionByNameAsync(getEmployeesRequest.PositionName) ??
                    throw new BadHttpRequestException($"Отсутвует позиция {getEmployeesRequest.PositionName}", 400);
                result = await _employeeRepository
                    .GetAllEmployeesByPositionId(positionEntity.Id)
                    .Select(x => _mapper.Map<GetEmployeesResponse>(x))
                    .ToListAsync();
            }
            else
            {
                result = await _employeeRepository
                    .GetAllEmployees()
                    .Select(x => _mapper.Map<GetEmployeesResponse>(x))
                    .ToListAsync();
                foreach (var item in result)
                {
                    if (item.Shifts.Count > 0)
                        item.ReprimandCount = GetReprimandCount(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Создание сотрудника
        /// </summary>
        /// <param name="createEmployeeRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        /// <exception cref="DataException"></exception>
        public async Task<CreateEmployeeResponse> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
        {
            Position positionEntity = await _positionRepository.GetPositionByNameAsync(createEmployeeRequest.PositionName) ??
                throw new DataException("Не удалось найти должность сотрудника");

            var employeeEntity = _mapper.Map<Employee>(createEmployeeRequest);
            employeeEntity.Position = positionEntity;

            await _employeeRepository.AddEmployeeAsync(employeeEntity);
            await _employeeUnitOfWork.SaveChanges();

            var createEmployeeResponse = _mapper.Map<CreateEmployeeResponse>(employeeEntity);

            return createEmployeeResponse;
        }

        /// <summary>
        /// Изменение сотрудника
        /// </summary>
        /// <param name="updateEmployeeRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        /// <exception cref="DataException"></exception>
        public async Task<UpdateEmployeeResponse> UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest)
        {
            if(updateEmployeeRequest.FirstName == "" & updateEmployeeRequest.LastName == "" & updateEmployeeRequest.MiddleName == "")
            {
                throw new BadHttpRequestException("Ни одно поле не заполнено для изменения сотрудника", 400);
            }
            Employee employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(updateEmployeeRequest.Id) ??
                throw new BadHttpRequestException($"Отсутвует пропуск по идентификатору {updateEmployeeRequest.Id}", 400);

            if (updateEmployeeRequest.PositionName != "")
            {
                Position positionEntity = await _positionRepository.GetPositionByNameAsync(updateEmployeeRequest.PositionName) ??
                    throw new DataException("Не удалось найти должность сотрудника");
                employeeEntity.Position = positionEntity;
            }
            if(updateEmployeeRequest.FirstName != "")
            {
                employeeEntity.FirstName = updateEmployeeRequest.FirstName;
            }
            if (updateEmployeeRequest.LastName != "")
            {
                employeeEntity.LastName = updateEmployeeRequest.LastName;
            }
            if (updateEmployeeRequest.MiddleName != "")
            {
                employeeEntity.MiddleName = updateEmployeeRequest.MiddleName;
            }

            await _employeeUnitOfWork.SaveChanges();

            var updateEmployeeResponse = _mapper.Map<UpdateEmployeeResponse>(employeeEntity);

            return updateEmployeeResponse;
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="deleteEmployeeRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task DeleteEmployeeAsync(DeleteEmployeeRequest deleteEmployeeRequest)
        {
            Employee employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(deleteEmployeeRequest.Id) ??
                    throw new BadHttpRequestException($"Отсутвует пропуск по идентификатору {deleteEmployeeRequest.Id}", 400);

            await _employeeRepository.RemoveEmployeeAsync(employeeEntity);
            await _employeeUnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Получение статистики замечаний сотрудника за месяц
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int GetReprimandCount(GetEmployeesResponse employee)
        {
            int result = 0;
            foreach (ShiftResponse shiftResponse in employee.Shifts)
            {
                if (shiftResponse.StartTime.Hour  > 9)
                {
                    result++;
                }
                if ((shiftResponse.EndTime.Hour <= 18 & shiftResponse.HoursWorked < 9 & employee.Position.Id != 3) ||
                    (shiftResponse.EndTime.Hour <= 21 & shiftResponse.HoursWorked < 12 & employee.Position.Id == 3))
                {
                    result++;
                }
            }
            return result;
        }
    }
}
