namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsPowerTrainServices
{
    Task<Result<PaginatedList<PowerTrainResponse>>> GetAllPowerTrains(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullPowerTrainResponse>>> GetAllFullPowerTrains(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FullPowerTrainResponse>> GetPowerTrainByID(string powerTrainID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FullPowerTrainResponse>>> GetPowerTrainsByName(string powerTrainName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PowerTrainResponse>> AddCombinationPowerTrain(CombinationPowerTrainRequest combinationPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> AddElectricPowerTrain(ElectricPowerTrainRequest electricPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> AddHybridPowerTrain(HybridPowerTrainRequest hybridPowerTrainRequest, CancellationToken cancellationToken = default);

    Task<Result<PowerTrainResponse>> UpdateCombinationPowerTrain(string powerTrainID, UpdateCombinationPowerTrainRequest updateCombinationPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> UpdateElectricPowerTrain(string powerTrainID, UpdateElectricPowerTrainRequest updateElectricPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> UpdateHybridPowerTrain(string powerTrainID, UpdateHybridPowerTrainRequest updateHybridPowerTrain, CancellationToken cancellationToken = default);

}
