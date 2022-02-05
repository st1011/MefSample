using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefSample.Common
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class UserNonShared: IUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
