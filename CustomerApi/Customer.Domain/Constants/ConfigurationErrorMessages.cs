using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Constants
{
    public static class ConfigurationErrorMessages
    {
        public static string ApiConfigurationNotFound(string api) => $"URL for {api} not found in configurations";
    }
}
