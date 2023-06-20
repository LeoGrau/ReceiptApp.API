using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Resources.Create;
using ReceiptApp.API.Security.Resources.Show;
using ReceiptApp.API.Security.Resources.Update;
using ReceiptApp.API.Security.Services;
using ReceiptApp.API.Shared.Domain.Repository;
using Swashbuckle.AspNetCore.Annotations;

namespace ReceiptApp.API.Security.Interface.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Receipts")]
[EnableCors]
public class ReceiptController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IReceiptService _receiptService;

    public ReceiptController(IMapper mapper, IReceiptService receiptService)
    {
        _mapper = mapper;
        _receiptService = receiptService;
    }

    [HttpGet("/all")]
    public async Task<IEnumerable<ReceiptResource>> GetAll()
    {
        var receipts = await _receiptService.ListAsync();
        var mappedReceipts = _mapper.Map<IEnumerable<Receipt>, IEnumerable<ReceiptResource>>(receipts);
        return mappedReceipts;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReceipt([FromBody,SwaggerRequestBody("")] CreateReceiptResource createReceiptResource)
    {
        var mappedReceipt = _mapper.Map<CreateReceiptResource, Receipt>(createReceiptResource);
        var result = await _receiptService.AddAsync(mappedReceipt);
        if (!result.Success)
            return BadRequest(result.Message);
        var showResultReceipt = _mapper.Map<Receipt, ReceiptResource>(result.Resource!);
        return Ok(showResultReceipt);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _receiptService.FindAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);
        var showResultReceipt = _mapper.Map<Receipt, ReceiptResource>(result.Resource!);
        return Ok(showResultReceipt);
    }

    [HttpGet("user/{userId}")]
    public async Task<IEnumerable<ReceiptResource>> GetReceiptsByUserId(Guid userId)
    {
        var receipts = await _receiptService.ListByUserIdAsync(userId);
        var mappedReceipts = _mapper.Map<IEnumerable<Receipt>, IEnumerable<ReceiptResource>>(receipts);
        return mappedReceipts;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReceipt(Guid id)
    {
        var result = await _receiptService.Remove(id);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully deleted."});
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReceipt(Guid id, [FromBody, SwaggerRequestBody("")] UpdateReceiptResource updateReceiptResource)
    {
        var mappedReceipt = _mapper.Map<UpdateReceiptResource, Receipt>(updateReceiptResource);
        var result = await _receiptService.UpdateAsync(id, mappedReceipt);
        if (!result.Success)
            return BadRequest(result.Message);
        var showResultReceipt = _mapper.Map<Receipt, ReceiptResource>(result.Resource!);
        return Ok(showResultReceipt);
    }

}