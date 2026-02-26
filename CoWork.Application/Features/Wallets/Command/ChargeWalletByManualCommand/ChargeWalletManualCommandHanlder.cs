using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Interfaces;
using CoWork.Application.Interfaces.MinIO;
using CoWork.Application.MarkerType;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Command.ChargeWalletByManualCommand
{
    public class ChargeWalletManualCommandHanlder :ICommandHandler<ChargeWalletManualCommand,Guid>   
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileStorageService _fileStorageService;
        public ChargeWalletManualCommandHanlder(IUnitOfWork unitOfWork, IFileStorageService fileStorageService)
        {
            _unitOfWork = unitOfWork;
            _fileStorageService = fileStorageService;
        }

        public async Task<Guid> Handle(ChargeWalletManualCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.WalletAccounts.GetByIdAsync(request.creditorWalletAccountId, cancellationToken);
            var receipt = await _fileStorageService.UploadFile<ReceiptImage>(request.fileStream,request.fileName,request.contentType,request.fileSize, cancellationToken);
            var transaction = wallet.IncreaseBalanceManual(wallet.Id, request.amount, receipt.FileName);
            await _unitOfWork.Transactions.AddAsync(transaction, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return transaction.Id;
        }
    }
}
