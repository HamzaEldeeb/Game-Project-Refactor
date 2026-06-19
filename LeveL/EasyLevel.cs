
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProjectRefactor.LeveL
{
        public class EasyLevel : BaseLevel
        {
            public override int Min => 0;
            public override int Max => 10;
            public override int NumberOfQuestions => 6;
            public override char[] Operators => new char[] { '+', '-' };


        }
  
}
