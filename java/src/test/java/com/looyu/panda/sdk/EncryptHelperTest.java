package com.looyu.panda.sdk;

import org.junit.Assert;
import org.junit.Test;

import java.util.UUID;

public class EncryptHelperTest {
    private String textToEncrypt = "将要加密的字符串";
    private String key ="5dd69f95-a82a-4b01-b6c1-a2d2f8f8061b";
    private String encryptedText = "neD0iV1eFLpIy4/F1XHFEh0bTP6bqV7HfChE9sbPsPk=";

    @Test
    public void encode() throws Exception {

        String encrypted = EncryptHelper.encode(textToEncrypt, key);
        Assert.assertEquals(encryptedText, encrypted);
    }

    @Test
    public void decode() throws Exception {
        String blankText = EncryptHelper.decode(encryptedText, key);
        Assert.assertEquals(textToEncrypt, blankText);
    }

}