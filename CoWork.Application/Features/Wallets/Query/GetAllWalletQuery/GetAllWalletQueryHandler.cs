using AutoMapper;
using CoWork.Application.Abstraction.CQRS;
using CoWork.Application.Features.Wallets.DTOs;
using CoWork.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Features.Wallets.Query.GetAllWalletQuery
{
    public class GetAllWalletQueryHandler : IQueryHandler<GetAllWalletQuery, IEnumerable<WalletAccountDto>>
{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 
        public GetAllWalletQueryHandler(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper; 
        }
        public async Task<IEnumerable<WalletAccountDto>> Handle(GetAllWalletQuery request, CancellationToken cancellationToken)
        {
            var Wallets = await _unitOfWork.WalletAccounts.GetAllAsync(cancellationToken);  
            return _mapper.Map<IEnumerable<WalletAccountDto>>(Wallets);   
            

        }
    }
}
