Feature: IDN e-mail addresses
	In order to use diacritics and non-latin characters in e-mail addresses
	As a math idiot
	I want to convert human input to Punycode/IDN and back as described in
	http://stackoverflow.com/questions/3140009/how-to-get-mailto-working-for-idn-email-ids
	and http://idn.icann.org/E-mail_test

Scenario: Unicode to IDN
	Given the e-mail address test@维奈.com
	When it is converted to PunyCode
	Then the result should be test@xn--ntsp09f.com

Scenario Outline: Unicode test examples
	Given the e-mail address <IDN address>
	When it is converted to PunyCode
	Then the result should be <Punycode>

	Examples:
	| IDN address                    | Punycode                                      | Script (language)                    |
	| mailtest@مثال.إختبار          | mailtest@xn--mgbh0fb.xn--kgbechtv             | Arabic                               |
	| mailtest@例子.测试             | mailtest@xn--fsqu00a.xn--0zwm56d              | Simplified Chinese                   |
	| mailtest@例子.測試             | mailtest@xn--fsqu00a.xn--g6w251d              | Traditional Chinese                  |
	| mailtest@παράδειγμα.δοκιμή     | mailtest@xn--hxajbheg2az3al.xn--jxalpdlp      | Greek                                |
	| mailtest@उदाहरण.परीक्षा          | mailtest@xn--p1b6ci4b4b3a.xn--11b5bs3a9aj6g   | Devanagari (Hindi)                   |
	| mailtest@例え.テスト           | mailtest@xn--r8jz45g.xn--zckzah               | Kanji, Hiragana, Katakana (Japanese) |
	| mailtest@실례.테스트           | mailtest@xn--9n2bp8q.xn--9t4b11yi5a           | Hangul (Korean)                      |
	| mailtest@مثال.آزمایشی        | mailtest@xn--mgbh0fb.xn--hgbk6aj7f53bba       | Perso-Arabic (Persian)               |
	| mailtest@пример.испытание     | mailtest@xn--e1afmkfd.xn--80akhbyknj4f        | Cyrillic (Russian)                   |
	| mailtest@உதாரணம்.பரிட்சை | mailtest@xn--zkc6cc5bi7f6e.xn--hlcj6aya9esc7a | Tamil                                |
	| mailtest@בײַשפּיל.טעסט         | mailtest@xn--fdbk5d8ap9b8a8d.xn--deba0ad      | Hebrew (Yiddish)                     |