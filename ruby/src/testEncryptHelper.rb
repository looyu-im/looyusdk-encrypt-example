# encoding: UTF-8
require 'test/unit'
require_relative "./encryptHelper"

$textToEncrypt = "将要加密的字符串"
$key ="5dd69f95-a82a-4b01-b6c1-a2d2f8f8061b"
$encryptedText = "neD0iV1eFLpIy4/F1XHFEh0bTP6bqV7HfChE9sbPsPk="

class TestEncryptHelper < Test::Unit::TestCase

  def test_encrypt

    helper = EncryptHelper.new()
    assert_equal($encryptedText,helper.encrypt($textToEncrypt,$key))
  end
  def test_decrypt

    helper = EncryptHelper.new()
    assert_equal($textToEncrypt,helper.decrypt($encryptedText,$key))
  end
end