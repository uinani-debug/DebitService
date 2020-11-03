using DebitLibrary.API.Entities;
using DebitService.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace DebitLibrary.API.Services
{
    public interface IDebitLibraryRepository
    {       
       bool DebitAmount(Debit accountNumber);
    //    bool DebitAmount(PaymentRequest accountNumber);

    }
}
