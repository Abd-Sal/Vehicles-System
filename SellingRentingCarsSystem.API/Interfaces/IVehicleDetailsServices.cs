namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsServices
{
    //Get
    Task<Result<PaginatedList<BodyTypeResponse>>> GetAllBodyTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> GetBodyTypeByID(string bodyTypeID, CancellationToken cancellationToken = default);
    Task<Result<BodyTypeResponse>> GetBodyTypeByName(string bodyTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<BodyTypeResponse>>> SearchBodyTypesByName(string bodyTypeName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<FeatureResponse>>> GetAllFeatures(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> GetFeatureByID(string featureID, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> GetFeatureByName(string featureName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FeatureResponse>>> SearchFeaturesByName(string featureName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<FuelTypeResponse>>> GetAllFuelTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> GetFuelTypeByID(string fuelTypeID, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> GetFuelTypeByName(string fuelTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FuelTypeResponse>>> SearchFuelTypesByName(string fuelTypeName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<MakeResponse>>> GetAllMakes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> GetMakeByID(string makeID,CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> GetMakeByName(string makeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<MakeResponse>>> SearchMakesByName(string makeName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<ModelResponse>>> GetAllModels(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ModelResponse>> GetModelByID(string modelID,CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<ModelResponse>>> GetModelsByMakeID(string makeID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<ModelResponse>>> GetModelsByName(string modelName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<PowerTrainResponse>>> GetAllPowerTrains(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> GetPowerTrainByID(string powerTrainID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<PowerTrainResponse>>> GetPowerTrainsByName(string powerTrainName, RequestFilters filters, CancellationToken cancellationToken = default);

    Task<Result<PaginatedList<TransmissionTypeResponse>>> GetAllTransmissionTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByID(string transmissionTypeID, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByName(string transmissionTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<TransmissionTypeResponse>>> SearchTransmissionTypesByName(string transmissionTypeName, RequestFilters filters, CancellationToken cancellationToken = default);
    
    Task<Result<PaginatedList<FuelDeliveryResponse>>> GetAllFuelDeliveries(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByID(string fuelDeliveryID, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByName(string fuelDeliveryName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FuelDeliveryResponse>>> SearchFuelDeliveriesByName(string fuelDeliveryName, RequestFilters filters, CancellationToken cancellationToken = default);
    
    Task<Result<PaginatedList<AspirationResponse>>> GetAllAspirations(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> GetAspirationByID(string aspirationID, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> GetAspirationByName(string aspirationName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<AspirationResponse>>> SearchAspirationsByName(string aspirationName, RequestFilters filters, CancellationToken cancellationToken = default);
    
    Task<Result<PaginatedList<ChargePortResponse>>> GetAllChargePorts(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> GetChargePortByID(string chargePortID, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> GetChargePortByName(string chargePortName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<ChargePortResponse>>> SearchChargePortsByName(string chargePortName, RequestFilters filters, CancellationToken cancellationToken = default);
    
    //Add 
    Task<Result<BodyTypeResponse>> AddBodyType(BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> AddFeature(FeatureRequest featureRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> AddFuelType(FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> AddMake(MakeRequest makeRequest, CancellationToken cancellationToken = default);
    Task<Result<ModelResponse>> AddModel(ModelRequest modelRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> AddCombinationPowerTrain(CombinationPowerTrainRequest combinationPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> AddElectricPowerTrain(ElectricPowerTrainRequest electricPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> AddHybridPowerTrain(HybridPowerTrainRequest hybridPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> AddTransmissionType(TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> AddFuelDelivery(FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> AddAspiration(AspirationRequest aspirationRequest, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> AddChargePort(ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default);

    //Update
    Task<Result<BodyTypeResponse>> UpdateBodyType(string bodyTypeID, BodyTypeRequest bodyTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<FeatureResponse>> UpdateFeature(string featureID, FeatureRequest featureRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> UpdateFuelType(string fuelTypeID, FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<MakeResponse>> UpdateMake(string makeID, MakeRequest makeRequest, CancellationToken cancellationToken = default);
    Task<Result<ModelResponse>> UpdateModel(string modelID, ModelRequest modelRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> UpdateCombinationPowerTrain(string powerTrainID, UpdateCombinationPowerTrainRequest updateCombinationPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> UpdateElectricPowerTrain(string powerTrainID, UpdateElectricPowerTrainRequest updateElectricPowerTrainRequest, CancellationToken cancellationToken = default);
    Task<Result<PowerTrainResponse>> UpdateHybridPowerTrain(string powerTrainID, UpdateHybridPowerTrainRequest updateHybridPowerTrain, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> UpdateTransmissionType(string transmissionTypeID, TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> UpdateFuelDelivery(string fuelDeliveryID, FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default);
    Task<Result<AspirationResponse>> UpdateAspirtaion(string aspirationID, AspirationRequest aspirationRequest, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> UpdateChargePort(string chargePortID, ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default);

}
