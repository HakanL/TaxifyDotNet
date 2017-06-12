using System;
using System.Collections.Generic;
using System.Text;

namespace Haukcode.TaxifyDotNet
{
    public enum ValidationStatuses
    {
        Unknown,
        ValidatedWithStreetLevelNormalization,
        Validated,
        StreetLevelOverride,
        CompleteOverride,
        NotValidated
    }
}
