using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Infastructure.Extensions
{
    /// <summary>
    /// Used to preform certificate methods that would not otherwsie be needed
    /// </summary>
    public class CertificateExtensions
    {
        private CertificateExtensions()
        {

        }
        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        [Conditional("DEBUG")]
        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
        }

        /// <summary>
        /// In Short: the Method solves the Problem of broken Certificates.
        /// Sometime when requesting Data and the sending Webserverconnection
        /// is based on a SSL Connection, an Error is caused by Servers whoes
        /// Certificate(s) have Errors. Like when the Cert is out of date
        /// and much more... So at this point when calling the method,
        /// this behaviour is prevented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns>true</returns>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
