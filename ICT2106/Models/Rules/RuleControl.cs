using System;

namespace ICT2106.Models.Rules
{
    public class Rule
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
