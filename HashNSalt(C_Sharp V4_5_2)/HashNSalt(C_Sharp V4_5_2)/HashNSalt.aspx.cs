using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Security.Cryptography;


namespace HashNSalt_C_Sharp_V4_5_2_
{
    public partial class HashNSalt : System.Web.UI.Page
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            lblSalt.Text = "Generating Salt";

            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            lblSalt.Text = "Salt Generated: " + Convert.ToBase64String(salt);
            lblHash.Text = "Hashing the text with the salt";

            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt);
            pbkdf2.IterationCount = PBKDF2_ITERATIONS;
            byte[] hash = pbkdf2.GetBytes(HASH_BYTE_SIZE);

            lblHash.Text = "Hashed text: " + Convert.ToBase64String(hash);

            lblValidate.Text = "Now you would store the hash and salt, and it's advisable that you store the interations in your database.<br/>To validate when someone logs in you take the salt and hash stored for that user, take the password<br/>they entered and re-hash it with the same salt as your stored hash...<br/>you should now have two identical hashes... comapre them with something like:<br/><br/>uint diff = (uint)OriginalHash.Length ^ (uint)NewHash.Length;<br/>for (int i = 0; i < OriginalHash.Length && i < NewHash.Length; i++)<br/>&nbsp;&nbsp;&nbsp;diff |= (uint)(OriginalHash[i] ^ NewHash[i]);< br />";
        }

    }
}