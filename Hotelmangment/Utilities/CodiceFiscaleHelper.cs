using System;
using System.Text;

namespace Hotel.Utilities
{
    public static class CodiceFiscaleHelper
    {
        public static string CalcolaCodiceFiscale(string nome, string cognome, DateTime dataDiNascita, string luogoDiNascita, string sesso)
        {
            string codiceCognome = EstraiCodiceCognome(cognome);
            string codiceNome = EstraiCodiceNome(nome);
            string codiceDataNascita = EstraiCodiceDataNascita(dataDiNascita, sesso);
            string codiceLuogoNascita = ComuniCatastaliHelper.GetCodiceCatastale(luogoDiNascita);

            string parziale = codiceCognome + codiceNome + codiceDataNascita + codiceLuogoNascita;

            string codiceFiscale = parziale + CalcolaCarattereDiControllo(parziale);

            return codiceFiscale.ToUpper();
        }

        private static string EstraiCodiceCognome(string cognome)
        {
            string consonanti = EstraiConsonanti(cognome);
            string vocali = EstraiVocali(cognome);

            string risultato = (consonanti + vocali + "XXX").Substring(0, 3);
            return risultato.ToUpper();
        }

        private static string EstraiCodiceNome(string nome)
        {
            string consonanti = EstraiConsonanti(nome);

            if (consonanti.Length > 3)
            {
                consonanti = string.Concat(consonanti[0], consonanti[2], consonanti[3]);
            }

            string vocali = EstraiVocali(nome);

            string risultato = (consonanti + vocali + "XXX").Substring(0, 3);
            return risultato.ToUpper();
        }

        private static string EstraiCodiceDataNascita(DateTime data, string sesso)
        {
            string anno = data.ToString("yy");
            string mese = "ABCDEHLMPRST"[data.Month - 1].ToString();
            int giorno = data.Day;

            if (sesso.ToUpper() == "F")
            {
                giorno += 40;
            }

            string giornoString = giorno.ToString("D2");

            return anno + mese + giornoString;
        }

        private static string CalcolaCarattereDiControllo(string parziale)
        {
            int[] valoriPari = new int[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            int[] valoriDispari = new int[]
            {
                1, 0, 5, 7, 9, 13, 15, 17, 19, 21,
                1, 0, 5, 7, 9, 13, 15, 17, 19, 21,
                1, 0, 5, 7, 9, 13
            };

            int somma = 0;

            for (int i = 0; i < parziale.Length; i++)
            {
                char c = parziale[i];

                if (i % 2 == 0)
                {
                    // Caratteri in posizione dispari
                    if (char.IsDigit(c))
                    {
                        somma += valoriDispari[c - '0'];
                    }
                    else
                    {
                        somma += valoriDispari[c - 'A' + 10];
                    }
                }
                else
                {
                    // Caratteri in posizione pari
                    if (char.IsDigit(c))
                    {
                        somma += valoriPari[c - '0'];
                    }
                    else
                    {
                        somma += valoriPari[c - 'A' + 10];
                    }
                }
            }

            return ((char)('A' + (somma % 26))).ToString();
        }

        private static string EstraiConsonanti(string input)
        {
            StringBuilder consonanti = new StringBuilder();

            foreach (char c in input)
            {
                if ("BCDFGHJKLMNPQRSTVWXYZ".IndexOf(char.ToUpper(c)) >= 0)
                {
                    consonanti.Append(c);
                }
            }

            return consonanti.ToString();
        }

        private static string EstraiVocali(string input)
        {
            StringBuilder vocali = new StringBuilder();

            foreach (char c in input)
            {
                if ("AEIOU".IndexOf(char.ToUpper(c)) >= 0)
                {
                    vocali.Append(c);
                }
            }

            return vocali.ToString();
        }
    }
}
