using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MefSample.Common
{
    [Export]
    internal class UserShared: IUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
