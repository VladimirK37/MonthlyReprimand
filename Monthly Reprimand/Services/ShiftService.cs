using MonthlyReprimand.Models.Request;
using MonthlyReprimand.Data.Context;
using MonthlyReprimand.Data.Entities;
using MonthlyReprimand.Data.Repositories;

namespace MonthlyReprimand.Services
{
    /// <summary>
    /// Сервис смены
    /// </summary>
    public class ShiftService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly ShiftRepository _shiftRepository;
        private readonly EmployeeUnitOfWork _employeeUnitOfWork;

        public ShiftService(EmployeeUnitOfWork employeeUnitOfWork, ShiftRepository shiftRepository, 
            EmployeeRepository employeeRepository)
        {
            _employeeUnitOfWork = employeeUnitOfWork;
            _shiftRepository = shiftRepository;
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Начало смены
        /// </summary>
        /// <param name="startShiftRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task StartShiftAsync(StartShiftRequest startShiftRequest)
        {
            Employee employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(startShiftRequest.Id) ??
                throw new BadHttpRequestException($"По номеру {startShiftRequest.Id} отсутвует сотрудник.", 400);

            if (employeeEntity.Shifts.Count() > 0)
            {
                var shift = employeeEntity.Shifts.OrderByDescending(x => x.StartTime).FirstOrDefault();
                if (shift.EndTime == default(DateTime))
                {
                    throw new BadHttpRequestException("Не может пройти кпп на вход пока не закроет предыдущую смену", 400);
                }
            }
            var shiftentity = new Shift()
            {
                StartTime = startShiftRequest.StartShift,
                Employee = employeeEntity
            };

            employeeEntity.Shifts.Add(shiftentity);
            await _shiftRepository.AddShiftAsync(shiftentity);

            await _employeeUnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Конец смены
        /// </summary>
        /// <param name="endShiftRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task EndShiftAsync(EndShiftRequest endShiftRequest)
        {
            var employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(endShiftRequest.Id) ??
                throw new BadHttpRequestException($"По номеру {endShiftRequest.Id} отсутвует сотрудник.", 400);

            if (employeeEntity.Shifts.Count() > 0)
            {
                var shift = employeeEntity.Shifts.OrderByDescending(x => x.StartTime).FirstOrDefault();
                if (shift.EndTime != default(DateTime))
                {
                    throw new BadHttpRequestException("Не может выйти пока не отметит начало своей смены");
                }
                if (shift.StartTime.Year == endShiftRequest.EndShift.Year & shift.StartTime.Month == endShiftRequest.EndShift.Month
                    & shift.StartTime.Day <= endShiftRequest.EndShift.Day)
                {
                    shift.EndTime = endShiftRequest.EndShift;
                    shift.Employee = employeeEntity;
                    shift.HoursWorked = (int)shift.EndTime.Subtract(shift.StartTime).TotalHours;
                }

                await _employeeUnitOfWork.SaveChanges();
            }
        }
    }
}
