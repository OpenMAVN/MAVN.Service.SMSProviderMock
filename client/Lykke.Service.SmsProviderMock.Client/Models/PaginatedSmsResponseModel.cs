using System.Collections.Generic;
using JetBrains.Annotations;

namespace Lykke.Service.SmsProviderMock.Client.Models
{
    /// <summary>
    /// Gives the List of Sms on the desired Page and information about the Page
    /// </summary>
    [PublicAPI]
    public class PaginatedSmsResponseModel
    {
        /// <summary>
        /// List of Sms for the given page
        /// </summary>
        public IEnumerable<SmsResponseModel> Sms { get; set; }

        /// <summary>
        /// Gives a TotalPageCount according to the currently selected page size
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// The CurrentPage selected
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
