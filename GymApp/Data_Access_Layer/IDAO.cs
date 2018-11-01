using System;
using System.Collections.Generic;
using System.Text;
using Model_Layer;

namespace Data_Access_Layer
{
    public interface IDAO
    {
        bool Create(User user);
        bool Update(User user);
    }
}
