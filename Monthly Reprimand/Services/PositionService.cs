using Microsoft.EntityFrameworkCore;
using MonthlyReprimand.Models.Response;
using MonthlyReprimand.Data.Repositories;

namespace MonthlyReprimand.Services
{
    /// <summary>
    /// Сервис должности
    /// </summary>
    public class PositionService
    {
        private readonly PositionRepository _positionRepository;

        public PositionService(PositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        /// <summary>
        /// Получение всех должностей
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetPositionsResponse>> GetAllPositionsAsync()
        {
            var result = await _positionRepository
                .GetAllPositions()
                .Select(x => new GetPositionsResponse()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
            return result;
        }
    }
}
