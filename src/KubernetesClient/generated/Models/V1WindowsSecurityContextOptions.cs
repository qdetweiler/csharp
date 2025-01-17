// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace k8s.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// WindowsSecurityContextOptions contain Windows-specific options and
    /// credentials.
    /// </summary>
    public partial class V1WindowsSecurityContextOptions
    {
        /// <summary>
        /// Initializes a new instance of the V1WindowsSecurityContextOptions
        /// class.
        /// </summary>
        public V1WindowsSecurityContextOptions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1WindowsSecurityContextOptions
        /// class.
        /// </summary>
        /// <param name="gmsaCredentialSpec">GMSACredentialSpec is where the
        /// GMSA admission webhook
        /// (https://github.com/kubernetes-sigs/windows-gmsa) inlines the
        /// contents of the GMSA credential spec named by the
        /// GMSACredentialSpecName field. This field is alpha-level and is only
        /// honored by servers that enable the WindowsGMSA feature
        /// flag.</param>
        /// <param name="gmsaCredentialSpecName">GMSACredentialSpecName is the
        /// name of the GMSA credential spec to use. This field is alpha-level
        /// and is only honored by servers that enable the WindowsGMSA feature
        /// flag.</param>
        public V1WindowsSecurityContextOptions(string gmsaCredentialSpec = default(string), string gmsaCredentialSpecName = default(string))
        {
            GmsaCredentialSpec = gmsaCredentialSpec;
            GmsaCredentialSpecName = gmsaCredentialSpecName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets gMSACredentialSpec is where the GMSA admission webhook
        /// (https://github.com/kubernetes-sigs/windows-gmsa) inlines the
        /// contents of the GMSA credential spec named by the
        /// GMSACredentialSpecName field. This field is alpha-level and is only
        /// honored by servers that enable the WindowsGMSA feature flag.
        /// </summary>
        [JsonProperty(PropertyName = "gmsaCredentialSpec")]
        public string GmsaCredentialSpec { get; set; }

        /// <summary>
        /// Gets or sets gMSACredentialSpecName is the name of the GMSA
        /// credential spec to use. This field is alpha-level and is only
        /// honored by servers that enable the WindowsGMSA feature flag.
        /// </summary>
        [JsonProperty(PropertyName = "gmsaCredentialSpecName")]
        public string GmsaCredentialSpecName { get; set; }

    }
}
