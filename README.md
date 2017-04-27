# CssAnimationSerializer
My try to type a syntax expression tree (not finished)

BNF Notations

<css3animation> ::= <name> <duration> <timingFunction> <delay> <iterationCount> <direction> <fillMode> <playState>
<name> ::= <identifier>
<duration> ::= <rule-duration>
<timingFunction> ::= <rule-duration>
<delay> ::= <rule-duration>
<iterationCount> ::= <digit> | <digit-list>
<direction> ::= <enumerator-identifier>
<fillMode> ::= <enumerator-identifier>
<playState> ::= <enumerator-identifier>
<rule-duration> ::= <digit> <enum-identifier> | <digit-list>, <enum-identifier>
<enum-specifier> ::= enum <identifier> { <enumerator-list> } | enum { <enumarator-list> } | enum <identifier>
<enumerator-identifier> ::= <enumerator> | <enumarator-list>, <enumarator>
<enumarator> ::= <constant> | <identifier> = <constant-expression>
<constant> ::= <integer-constant> | <character-constant> | <enumeration-constant>


<keyframes> ::= <name> <selector-list>
<name> ::= <identifier>
<selector-list> ::= <selector> | { <selector> }
<selector> ::= <selector-name> <selector-value>
<selector-name> ::= <identifier>
<selector-value> ::= <rule-selector>
<rule-selector> ::= <enum-identifier> | <identifier> | <digit> <enum-identifier>
<enumerator-identifier> ::= <enumerator> | <enumarator-list>, <enumarator>
<enumarator> ::= <constant> | <identifier> = <constant-expression>
<constant> ::= <integer-constant> | <character-constant> | <enumeration-constant>

		Client
		  |
		  v
	-----------------
	|				|
	v				v
Context		Abstract Expression<------------
					^					   |
					|       			   |
			---------------------		   |
			|					|		   |
		Terminal			Nonterminal	   |
								.		   |
								|		   |
								------------