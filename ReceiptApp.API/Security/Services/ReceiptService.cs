using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Domain.Services.Communication;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Security.Services;

public class ReceiptService : IReceiptService
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReceiptService(IReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Receipt>> ListAsync()
    {
        return await _receiptRepository.ListAsync();
    }

    public async Task<IEnumerable<Receipt>> ListByUserIdAsync(Guid userId)
    {
        return await _receiptRepository.ListByUserIdAsync(userId);
    }

    public async Task<ReceiptResponse> FindAsync(Guid id)
    {
        var existingReceipt = await _receiptRepository.FindAsync(id);
        if (existingReceipt == null)
            return new ReceiptResponse("Receipt does not exist.");
        return new ReceiptResponse(existingReceipt);
    }

    public async Task<ReceiptResponse> AddAsync(Receipt receipt)
    {
        try
        {
            await _receiptRepository.AddAsync(receipt);
            await _unitOfWork.CompleteAsync();
            return new ReceiptResponse(receipt);
        }
        catch(Exception exception)
        {
            return new ReceiptResponse($"{exception.Message}");
        }
    }

    public async Task<ReceiptResponse> Remove(Guid id)
    {
        var existingReceipt = await _receiptRepository.FindAsync(id);
        if (existingReceipt == null)
            return new ReceiptResponse("Receipt does not exist.");
        try
        {
            _receiptRepository.Remove(existingReceipt);
            await _unitOfWork.CompleteAsync();
            return new ReceiptResponse(existingReceipt);
        }
        catch(Exception exception)
        {
            return new ReceiptResponse($"{exception.Message}");
        }
    }
}