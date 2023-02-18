﻿using Refit;

namespace Customer.Infra.HttpClients.ViaCep
{
    public interface IViaCepClient
    {
        [Get("/ws/{cep}/json")]
        Task<ViaCepResponse> GetAddressDataAsync(string cep);
    }
}
