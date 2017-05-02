# CssAnimationSerializer
My try to type a syntax expression tree (not finished)

BNF Notations

\<css3animation\> ::= \<name\> \<duration\> \<timingFunction\> \<delay\> \<iterationCount\> \<direction\> \<fillMode\> \<playState\>\n
\<name\> ::= \<identifier\>\n
\<duration\> ::= \<rule-duration\>\n
\<timingFunction\> ::= \<rule-duration\>\n
\<delay\> ::= \<rule-duration\>\n
\<iterationCount\> ::= \<digit\> | \<digit-list\>\n
\<direction\> ::= \<enumerator-identifier\>\n
\<fillMode\> ::= \<enumerator-identifier\>\n
\<playState\> ::= \<enumerator-identifier\>\n
\<rule-duration\> ::= \<digit\> \<enum-identifier\> | \<digit-list\>, \<enum-identifier\>\n
\<enum-specifier\> ::= enum \<identifier\> { \<enumerator-list\> } | enum { \<enumarator-list\> } | enum \<identifier\>\n
\<enumerator-identifier\> ::= \<enumerator\> | \<enumarator-list\>, \<enumarator\>\n
\<enumarator\> ::= \<constant\> | \<identifier\> = \<constant-expression\>\n
\<constant\> ::= \<integer-constant\> | \<character-constant\> | \<enumeration-constant\>\n\n
\<keyframes\> ::= \<name\> \<selector-list\>\n
\<name\> ::= \<identifier\>\n
\<selector-list\> ::= \<selector\> | { \<selector\> }\n
\<selector\> ::= \<selector-name\> \<selector-value\>\n
\<selector-name\> ::= \<identifier\>\n
\<selector-value\> ::= \<rule-selector\>\n
\<rule-selector\> ::= \<enum-identifier\> | \<identifier\> | \<digit\> \<enum-identifier\>\n
\<enumerator-identifier\> ::= \<enumerator\> | \<enumarator-list\>, \<enumarator\>\n
\<enumarator\> ::= \<constant\> | \<identifier\> = \<constant-expression\>\n
\<constant\> ::= \<integer-constant\> | \<character-constant\> | \<enumeration-constant\>\n

        Client\n
          |\n
          v\n
     ----------------\n
     |              |\n
	 v				v\n
Context     Abstract Expression\<-----------\n
                    ^                      |\n
                    |                      |\n
            ---------------------          |\n
			|					|          |\n
          Terminal			Nonterminal    |\n
                                .          |\n
                                |          |\n
                                ------------\n