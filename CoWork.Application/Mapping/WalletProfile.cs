using AutoMapper;
using CoWork.Application.Features.Wallets.DTOs;
using CoWork.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoWork.Application.Mapping
{
    public class WalletProfile:Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletAccount, WalletAccountDto>();
        }
    }
}
