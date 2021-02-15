using System;

namespace ICT2106.Models.Rules
{
    public class Rule2
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
