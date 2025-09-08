namespace SellingRentingCarsSystem.API.Controllers;

[Route("api/customers")]
[ApiController]
[Authorize]
public class CustomersController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetAllCustomerAsync(
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.CustomerServices.GetAllCustmomersAsync(filters, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpGet("{customerID}")]
    public async Task<IActionResult> GetCustomerByID(
    [FromRoute] string customerID,
    CancellationToken cancellationToken = default)
    {
        var temp = await unitOfWork.CustomerServices.GetCustmomerAsync(customerID, cancellationToken);
        if (temp.IsSuccess)
            return Ok(temp.Value);
        return temp.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(
        [FromBody] CustomerRequest customerRequest,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.AddCustmomer(customerRequest, cancellationToken);
        if (temp.IsSuccess)
            return CreatedAtAction(
                        actionName: nameof(GetCustomerByID),
                        routeValues: new { customerID = temp.Value.Id },
                        value: temp.Value);
        return temp.ToProblem();
    }

    [HttpPut("{customerID}")]
    public async Task<IActionResult> UpdateCustomerAsync(
        [FromRoute] string customerID,
        [FromBody] CustomerRequest customerRequest,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.UpdateCustmomer(customerID, customerRequest, cancellationToken);
        if (temp.IsSuccess) return NoContent();
        return temp.ToProblem();
    }

    [HttpGet("{customerName}/search-by-name")]
    public async Task<IActionResult> SearchForCustomers(
        [FromRoute] string customerName,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.SearchForCustmomers(customerName, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("{customerID}/rent-history")]
    public async Task<IActionResult> RentHistoryByCustomerIDAsync(
        [FromRoute] string customerID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.RentHistoryByCustmomer(customerID, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("{customerID}/sell-history")]
    public async Task<IActionResult> SellHistoryByCustomerIDAsync(
        [FromRoute] string customerID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.SellHistoryByCustmomer(customerID, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }
    
    [HttpGet("{customerID}/books")]
    public async Task<IActionResult> BooksByCustomerIDAsync(
        [FromRoute] string customerID,
        [FromQuery] RequestFilters filters,
        CancellationToken cancellationToken = default
        )
    {
        var temp = await unitOfWork.CustomerServices.CustomerBooks(customerID, filters, cancellationToken);
        if (temp.IsSuccess) return Ok(temp.Value);
        return temp.ToProblem();
    }


}
