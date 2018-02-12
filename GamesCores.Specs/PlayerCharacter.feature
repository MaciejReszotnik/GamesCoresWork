Feature: PlayerCharacter
	In order to have consistent character attributes
	As a player
	I want my character attributes to react consistently to changes. 

Scenario Outline: Taking damage reduces health
	Given I have a character
	When I take <damage> damage
	Then my health should be <remainingHealth>

	Examples:
	| damage | remainingHealth |
	| 0      | 100             |
	| 30     | 70              |
	| 50     | 50              |
	| 100    | 0               |

Scenario: Taking too much damage kills the character
	Given I have a character
	When he receives 100 damage 
	Then he should have 0 health
	And he should be dead

Scenario: Elf race characters get additional 20 damage resistance
	Given I have a character
		And the character has damage resistance of 10 
		And the character is an Elf
	When he receives 40 damage
	Then he should have 90 health

	Scenario: Elf race characters get additional 20 damage resistance using data table
	Given I have a character
		And the character has the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |
	When he receives 40 damage
	Then he should have 90 health

	Scenario: Healers restore all health
	Given I have a character
	Given the character class is Healer
	When he receives 40 damage
		And he casts healing spell
	Then he should have 100 health


