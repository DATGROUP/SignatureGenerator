import org.apache.commons.codec.binary.Base64;
import org.apache.commons.codec.digest.DigestUtils;
import org.bouncycastle.openpgp.PGPEncryptedDataGenerator;
import org.bouncycastle.openpgp.PGPException;
import org.bouncycastle.openpgp.examples.ByteArrayHandler;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.security.*;

public class Main {

    static
    {
        // init Bouncy Castle Provider
        Security.addProvider(new org.bouncycastle.jce.provider.BouncyCastleProvider());
    }

    private static byte[] removeZero( byte[] input ) {
        byte[] ret = null;
        for ( int n = input.length - 1; n >= 0; n-- ) {
            if ( input[n] > 0 ) {
                ret = new byte[n + 1];
                System.arraycopy( input, 0, ret, 0, n + 1 );
                break;
            }
        }
        return ret;
    }

    private static byte[] pad( byte[] input ) {
        byte[] ret = new byte[Double.valueOf( Math.ceil( (double) input.length / 16 ) ).intValue() * 16];
        System.arraycopy( input, 0, ret, 0, input.length );
        return ret;
    }

    public static void main(String[] args) {
        System.out.println("-----------------------------");
        System.out.println("DAT Signature Creator");
        System.out.println("-----------------------------");
		
		//ToDo: insert user data
        String userName = "userName";
        String customerNo = "customerNo";
        String password = "password";
		
        System.out.print("Login    : ");
        System.out.println(userName);
        System.out.print("Customer : ");
        System.out.println(customerNo);
        System.out.print("Password : ");
        System.out.println(password);
        System.out.println("-----------------------------");
        System.out.println("");
        System.out.println("calculate signature ...");
        System.out.println("");

        String clearData = customerNo + ":" + userName;
        String pgpSig = "";
        try {
            pgpSig = PGPencrypt(clearData, password);
        } catch (Exception e) {
            System.out.println("PGP encryption failed");
            System.out.println(e.getMessage());
        }
        System.out.print("Signature (PGP RAW)         : ");
        System.out.println(pgpSig);

        System.out.print("Signature (PGP URL-ENCODED) : ");
        try {
            System.out.println(URLEncoder.encode(pgpSig, "UTF-8"));
        } catch (UnsupportedEncodingException ueex) {
            System.out.println("Illegal encoding");
        }
        System.out.println("");

        String aesSig = "";
        try {
            aesSig = AESencrypt(clearData, password);
        } catch (Exception e) {
            System.out.println("AES encryption failed");
            System.out.println(e.getMessage());
        }
        System.out.print("Signature (AES RAW)         : ");
        System.out.println(aesSig);

        System.out.print("Signature (AES URL-ENCODED) : ");
        try {
            System.out.println(URLEncoder.encode(aesSig, "UTF-8"));
        } catch (UnsupportedEncodingException ueex) {
            System.out.println("Illegal encoding");
        }
        System.out.println("");

    }

    /**
     * Simple PGP encryptor between byte[].
     *
     * @param clearData  The test to be encrypted
     * @param passPhrase The pass phrase (key).  This method assumes that the
     *                   key is a simple pass phrase, and does not yet support
     *                   RSA or more sophisiticated keying.
     * @return encrypted data.
     * @throws java.io.IOException
     * @throws PGPException
     * @throws java.security.NoSuchProviderException
     */
    public static byte[] PGPencrypt(
            byte[] clearData,
            char[] passPhrase )
            throws IOException, PGPException, NoSuchProviderException
    {
        return ByteArrayHandler.encrypt( clearData, passPhrase, "iway", PGPEncryptedDataGenerator.CAST5, false );
    }

    /**
     * encoded String(clearData) with additional Base64 encoding
     *
     * @param clearData
     * @param passPhrase
     * @return
     * @throws IOException
     * @throws PGPException
     * @throws NoSuchProviderException
     */
    public static String PGPencrypt( String clearData, String passPhrase ) throws IOException, PGPException, NoSuchProviderException {
        return new String(Base64.encodeBase64(PGPencrypt(clearData.getBytes("UTF-8"), passPhrase.toCharArray()) ), "UTF-8" );
    }

    /**
     * Simple AES encryptor between byte[].
     *
     * @param clearData  The test to be encrypted
     * @param passPhrase The pass phrase (key).  This method assumes that the
     *                   key is a simple pass phrase, and does not yet support
     *                   RSA or more sophisiticated keying.
     * @return encrypted data.
     * @throws IOException
     * @throws java.security.NoSuchAlgorithmException
     * @throws javax.crypto.NoSuchPaddingException
     * @throws java.security.InvalidKeyException
     * @throws javax.crypto.IllegalBlockSizeException
     * @throws javax.crypto.BadPaddingException
     * @throws java.security.InvalidAlgorithmParameterException
     *
     */

    private static byte[] AESencrypt(
            byte[] clearData,
            byte[] passPhrase )
            throws IOException, NoSuchAlgorithmException, NoSuchPaddingException, InvalidKeyException, IllegalBlockSizeException, BadPaddingException, InvalidAlgorithmParameterException
    {
        SecretKeySpec skeySpec = new SecretKeySpec( DigestUtils.md5(passPhrase), "AES" );
        Cipher c = Cipher.getInstance( "AES/ECB/NoPadding" );
        c.init( Cipher.ENCRYPT_MODE, skeySpec );
        return removeZero( c.doFinal( pad( clearData ) ) );
    }


    public static String AESencrypt( String clearData, String passPhrase )
           throws IOException, NoSuchAlgorithmException, NoSuchPaddingException, NoSuchProviderException, InvalidKeyException, IllegalBlockSizeException, BadPaddingException, InvalidAlgorithmParameterException {
        return new String(Base64.encodeBase64(AESencrypt(clearData.getBytes("UTF-8"), passPhrase.getBytes("UTF-8")) ), "UTF-8" );
    }


}
