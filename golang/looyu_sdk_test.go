package main

import (
	"testing"
	"looyu_sdk"
)

func TestEncryptHelper(t *testing.T) {
	key := "5dd69f95-a82a-4b01-b6c1-a2d2f8f8061b"
	str := "将要加密的字符"
	encrypted := "neD0iV1eFLpIy4/F1XHFEomEfx2kV/EPMg+edO9TU/8="
	encryptMsg, _ := looyu_sdk.Encrypt(str, key)
	if encryptMsg != encrypted {
		t.Error(encryptMsg, encrypted)
	}

	decryptMsg, _ := looyu_sdk.Decrypt(encryptMsg, key)
	if decryptMsg != str {
		t.Error(decryptMsg, str)
	}
}
