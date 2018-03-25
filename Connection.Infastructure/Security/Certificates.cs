using System;
using System.Security.Cryptography.X509Certificates;

namespace Connection.Infastructure.Security
{
    /// <summary>
    /// 
    /// </summary>
    public static class Certificates
    {
        public static X509Certificate2 GetX509ClientCertificate()
        {
            X509Store userCaStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            try
            {

                userCaStore.Open(OpenFlags.ReadOnly);
                foreach (X509Certificate2 mCert in userCaStore.Certificates)
                {

                    int a = 1;
                    //TODO's
                }
                X509Certificate2Collection certificatesInStore = userCaStore.Certificates;
                X509Certificate2Collection findResult = certificatesInStore.Find(X509FindType.FindByIssuerName, "Space.Radar.Client", true);

                // X509Certificate2Collection findResult = certificatesInStore.Find(X509FindType.FindBySubjectName, "localtestclientcert", true);
                // X509Certificate2Collection findResult = certificatesInStore.Find(X509FindType.FindBySubjectName, "mylocalsite.local", true);

                X509Certificate2 clientCertificate = null;
                if (findResult.Count == 1)
                {
                    clientCertificate = findResult[0];
                }
                else
                {
                    throw new Exception("Unable to locate the correct client certificate.");
                }
                return clientCertificate;
            }
            catch
            {
                throw;
            }
            finally
            {
                userCaStore.Close();
            }
        }

    }

}
