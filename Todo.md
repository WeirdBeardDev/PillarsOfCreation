# Todo Ideas
## General Ideas
- TBD

## Current Work
- TODO update `PlayerCharacter` to store name, scores, skills (TBD), starting location, inventory (TBD)
- DESIGN the create a character process - include first time visit, returning visits, etc.
- end of list

## Backlog
- RESEARCH ways to use less verbose json when saving to local storage
- CREATE 4 empty character slots if none exist
- CREATE a basic character (name, 1 stat, image)
- VIEW display the created characters
- CREATE add a credits page
- CREATE add the list of icons from the readme.md to the credits page
- ADD `bootstrap-icons` v1.13.1 from jsDelivr using libman
- UPDATE icons to use the bootstrap-icons
- RESEARCH ways to use a tick-based timing system, configurable so game time can run at different rates
- CREATE build a skills system, update the `Skills` in `PlayerCharacter`
- CREATE build a location system, update the `StartingLocation` in `PlayerCharacter`
- CREATE build a item and inventory system, update the `Items` in `PlayerCharacter`
- UPDATE on `CharacterSelector` only show the delete action if a character exists in the slot
- RESEARCH if I want/need custom deserializtion object to support items like
  - support both `{ "Strength": 12 }` and `{ "Strength": { "Score": 12 } }` when (de)serializing `Stats` or other items

## Feature List

| Feature   | Definition                                                                               |
| :-------- | :--------------------------------------------------------------------------------------- |
| Character | Anything dealing with the player's active character                                      |
| Data      | Anything dealing with the game data                                                      |
| DevTools  | Any tool that helps with development                                                     |
| General   | Anything that doesn't fit into the other categories                                      |
| Logging   | Anything dealing with logging in the game, specifically player read logs of game actions |
| Player    | Anything dealing with the player's account and all their characters                      |
| Timer     | Anything dealing with the timer service                                                  |
| Save      | Anything dealing with the data service for loading/saving of the game                    |

---

# Processes
## Standard Actions
### Cancel
1. Cancel current action and run the assigned `EventCallback OnBack`

## Character Actions
### Visit Site
1. Check localStorage for `Data.PlayerName`
   1. EXISTS: [Select Character](#select-character), [Delete Character](#delete-character) (if one exists), [Create Character](#create-character) (if slot available), [Cancel](#cancel)
   2. NOT: [Create Character](#create-character), [Cancel](#cancel)

### Select Character
This option is only available if at least one character exists in the save data.
1. Set `LastActiveSlot` to the slot number
2. Start the game with the selected character

### Delete Character
This option is only available if at least one character exists in the save data.
1. Click the delete button
2. Ask the user to confirm the deletion
3. Delete character from the save data
4. If this was the last character played change `LastActiveSlot` to -1
5. Stay on the same screen
   1. Assumption: this is the character selection/creation screen

### Create Character
This option is only available if at least one slot is available to create a character.
1. Change page to allow creating a new character
2. Show character slots
3. Ask player to pick a slot
4. If slot already has a player then
   1. Ask to delete the existing player
   2. NO: "reload" page and start over
   3. YES: continue
   4. Delete player from the slot
5. Change display to create a character
6. Enter a player name
7. Assign starter ability score points
8. Assign starter skill points
9. Pick starting location
   1. Earth
   2. Moon
   3. Mars
10. Pick a startr item pack
11. Click "Create Character"
   1. Validate all entries are valid
   2. Save character to `Player` and get save slot number
   3. Set `LastActiveSlot` to save slot number
   4. Start the game with the created character
