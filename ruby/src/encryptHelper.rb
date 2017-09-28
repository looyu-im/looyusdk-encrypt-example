# encoding: UTF-8
require 'base64'
require 'openssl'
require 'digest'

class EncryptHelper
  def initialize()

  end

  def encrypt(blank, key)
    cipher = OpenSSL::Cipher.new("AES-128-CBC")
    cipher.encrypt
    cipher.iv = "0123456789ABCDEF"
    cipher.key = Digest::MD5.digest(key)
    encrypted = cipher.update(blank) + cipher.final
    Base64.encode64(encrypted).chomp
  end

  def decrypt(encrypted, key)
    encryptedText = Base64.decode64(encrypted)
    cipher = OpenSSL::Cipher.new("AES-128-CBC")
    cipher.decrypt
    cipher.iv = "0123456789ABCDEF"
    cipher.key = Digest::MD5.digest(key)
    blank = cipher.update(encryptedText) + cipher.final
    blank.force_encoding("iso-8859-1").force_encoding('utf-8')
  end
end
