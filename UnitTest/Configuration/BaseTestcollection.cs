using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Configuration
{
    [CollectionDefinition("Base collection")]

    public class BaseTestcollection : ICollectionFixture<BaseTextFixture>
    {
         
    }
}
