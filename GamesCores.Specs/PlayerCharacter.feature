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

Scenario: Total magic power:
	Given I have a character
	Given I have the following magic items
		| name   | value | power |
		| Ring   | 200   | 100   |
		| Amulet | 400   | 200   |
		| Gloves | 100   | 400   |
	Then the total magic power should be 700

Scenario: Reading restore heath store when overtired has no effect
	Given I have a character
	Given character last slept 3 days ago
	When he receives 40 damage
	And the character reads a restore health scroll
	Then he should have 60 health

Scenario: Weapons are worth money
	Given I have the following weapons
	| name  | value |
	| Sword | 50    |
	| Pick  | 40    |
	| Knife | 10    |
	Then my weapons should be worth 100

Scenario: Elf race characters don't lose  magical item power
	Given I am an Elf
		And I have an Amulet with power of 200
	When I use magical Amulet
	Then the Amulet power should not be reduced