using System.Collections;
using UnityEngine;

/// <summary>
/// 文字列の暗号化、複合化を行うクラス
/// </summary>
public static class StringEncryption
{
    //=================================================================================
    //暗号化
    //=================================================================================

    /// <summary>
    /// 文字列を暗号化する
    /// </summary>
    public static string Encrypt(string sourceString)
    {

        //RijndaelManagedオブジェクトを作成
        System.Security.Cryptography.RijndaelManaged rijndael =
          new System.Security.Cryptography.RijndaelManaged();

        //パスワードから共有キーと初期化ベクタを作成
        byte[] key, iv;
        GenerateKeyFromPassword(
          rijndael.KeySize, out key, rijndael.BlockSize, out iv);
        rijndael.Key = key;
        rijndael.IV = iv;

        //文字列をバイト型配列に変換する
        byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(sourceString);

        //対称暗号化オブジェクトの作成
        System.Security.Cryptography.ICryptoTransform encryptor =
          rijndael.CreateEncryptor();

        //バイト型配列を暗号化する
        byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);

        //閉じる
        encryptor.Dispose();

        //バイト型配列を文字列に変換して返す
        return System.Convert.ToBase64String(encBytes);
    }

    //=================================================================================
    //復号化
    //=================================================================================

    /// <summary>
    /// 暗号化された文字列を復号化する
    /// </summary>
    public static string Decrypt(string sourceString)
    {

        //RijndaelManagedオブジェクトを作成
        System.Security.Cryptography.RijndaelManaged rijndael =
          new System.Security.Cryptography.RijndaelManaged();

        //パスワードから共有キーと初期化ベクタを作成
        byte[] key, iv;
        GenerateKeyFromPassword(
          rijndael.KeySize, out key, rijndael.BlockSize, out iv);
        rijndael.Key = key;
        rijndael.IV = iv;

        //文字列をバイト型配列に戻す
        byte[] strBytes = System.Convert.FromBase64String(sourceString);

        //対称暗号化オブジェクトの作成
        System.Security.Cryptography.ICryptoTransform decryptor =
          rijndael.CreateDecryptor();

        //バイト型配列を復号化する
        //復号化に失敗すると例外CryptographicExceptionが発生
        byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);

        //閉じる
        decryptor.Dispose();

        //バイト型配列を文字列に戻して返す
        return System.Text.Encoding.UTF8.GetString(decBytes);
    }

    //=================================================================================
    //共通
    //=================================================================================

    //パスワードから共有キーと初期化ベクタを生成する
    private static void GenerateKeyFromPassword(int keySize, out byte[] key, int blockSize, out byte[] iv)
    {
        //パスワードから共有キーと初期化ベクタを作成する
        //saltを決める
        byte[] salt = System.Text.Encoding.UTF8.GetBytes("saltは必ず8バイト以上");

        //Rfc2898DeriveBytesオブジェクトを作成する
        string pass = "kokonirandamunapass1";

        System.Security.Cryptography.Rfc2898DeriveBytes deriveBytes =
          new System.Security.Cryptography.Rfc2898DeriveBytes(pass, salt);

        //反復処理回数を指定する デフォルトで1000回
        deriveBytes.IterationCount = 1000;

        //共有キーと初期化ベクタを生成する
        key = deriveBytes.GetBytes(keySize / 8);
        iv = deriveBytes.GetBytes(blockSize / 8);
    }
}
