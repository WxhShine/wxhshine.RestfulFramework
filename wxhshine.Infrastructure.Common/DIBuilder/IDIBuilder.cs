using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace wxhshine.Infrastructure.Common.DIBuilder
{
    public interface IDIBuilder
    {
        void DIBuilder(IServiceCollection services);
    }
}
