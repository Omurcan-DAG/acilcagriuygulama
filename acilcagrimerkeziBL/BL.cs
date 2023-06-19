using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using acilcagrimerkeziveritabanıDL;

namespace acilcagrimerkeziveritabanıBL
{
    public static class BL
    {
        public static List<cagri> cagriler = new List<cagri>();
        public static string error = "";
        public static bool cagriekle( DateTime saattarih, string adı, string soyadı, string telefon, string adres, string birim, string olay)
        {
            cagri k = new cagri()
            {
                cagriid = Guid.NewGuid().ToString(),
                saattarih = saattarih,
                adı = adı,
                soyadı = soyadı,
                telefon = telefon,
                adres = adres,
                birim = birim,
                olay = olay
            };

            int res = DL.cagriekle(k.cagriid, k.saattarih, k.adı, k.soyadı, k.telefon, k.adres, k.birim, k.olay,  out error);
            if (res > 0)
            {
                cagriler.Add(k);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool cagriduzenle(string cagriid, DateTime saattarih, string adı, string soyadı, string telefon, string adres, string birim, string olay )
        {
            cagri k =cagriler.Find(o => o.cagriid == cagriid);
            if (k != null)
            {
                int res = DL.cagriduzenle(k.cagriid, saattarih, adı, soyadı, telefon, adres, birim, olay out error);
                if (res > 0)
                {
                    k.saattarih = saattarih;
                    k.adı = adı;
                    k.soyadı = soyadı;
                    k.telefon = telefon;
                    k.adres = adres;
                    k.birim = birim;
                    k.olay = olay;
                    

                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public static bool cagrisil(string cagriid)
        {
            int res = DL.cagrisil(cagriid, out error);
            if (res > 0)
            {
                cagri k = cagriler.Find(o => o.cagriid == cagriid);
                cagriler.Remove(k);
                return true;
            }
            else
                return false;
        }
        public static bool tumcagrilerilistele()
        {
            var list = DL.tumcagriler(out error);
            if (list == null)
                return false;

            cagriler = new List<cagri>();
            foreach (var e in list)
            {
                cagriler.Add(new cagri()
                {
                    cagriid = e.cagriid,
                    saattarih = e.saattarih,
                    adı = e.adı,
                    soyadı = e.soyadı,
                    telefon = e.telefon,
                    adres = e.adres,
                    birim = e.birim,
                    olay = e.olay,
                });
            }

            return true;
        }
    }
}
