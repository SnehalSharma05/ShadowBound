# ShadowBound - Project Documentation

## Overview
**ShadowBound** is a 2D runner game developed using Unity. The game challenges players to navigate through a mysterious forest split into two mirrored dimensions: the **Player World** and the **Shadow World**. Both worlds are split horizontally, with the player and shadow characters controlled simultaneously by the same inputs. Despite being controlled together, the player and shadow can move independently of one another.

## Game Objective
The primary goal of ShadowBound is to navigate through a series of obstacles while keeping the shadow attached to the player. If the shadow becomes detached, the player has 5 seconds to reunite with the shadow before the game ends. Players can collect a power-up that allows them to instantly teleport the shadow back to the player’s position, adding a strategic element to the gameplay.

## Key Features
- **Dual World Mechanic**: The game is divided into two horizontal sections - the Player World and the Shadow World. Each world has its own unique set of obstacles that the player must overcome.
- **Shadow Attachment**: The shadow mirrors the player's movements, but the two are not strictly bound. The challenge lies in navigating both worlds simultaneously without allowing the shadow to detach for too long.
- **Power-Up**: A single power-up is available, allowing the player to teleport the shadow back to their position instantly. This power-up adds a layer of strategy to the gameplay, as it must be used wisely.
- **Game Over Condition**: If the shadow remains detached for more than 5 seconds, or if it leaves the visible screen, the game ends.
- **Forest Theme**: The game is set in a dark, mysterious forest with a noir color scheme. The atmosphere is inspired by games like Limbo, with a haunting and immersive environment.
- **Original Artwork and Animations**: All game assets, including sprites and animations, were created using GIMP or sourced from royalty-free resources. No Unity Store assets were used. The character animations (jump, land, walk) were crafted by rigging sprites with bones and keyframing their movements.

## Inspirations
The design and atmosphere of ShadowBound were inspired by the game **Limbo**. The minimalist, monochromatic art style and the eerie, atmospheric setting are key elements that define the visual and thematic tone of the game.

## Development Tools
(I have not used any unity store assets in the creation of this game to showcase my abilities to the fullest extent.)
- **Game Engine**: Unity
- **Art and Sprites**: GIMP, royalty-free sources
- **Animation**: Custom animations created by rigging sprites with bones and keyframing movements.

## Installation & Setup
1. **Clone the Repository**: 
   ```bash
   https://github.com/SnehalSharma05/ShadowBound

2. **Open in Unity:**
- Open Unity Hub and click on "Add".
- Navigate to the cloned repository folder and select it.
- Click "Add Project" and open it in Unity.

**Alternately, you can download the executable file in ShadowBound-executable on GitHub.(Not Recommended - Jittery)**

3. **Play the Game:**
Once the project is open, click on the "Play" button in the Unity Editor to start the game.

## How to Play
(Note that this game is intentionally difficult to play and requires time to master timing and patterns)
- **Movement:** Use the arrow keys for movement and the space bar for jumping.
- **Objective:** Navigate through obstacles in both the Player World and Shadow World while ensuring the shadow stays attached to the player.(IMPORTANT TIP: Leverage the obstacles to keep the player at a position while you attempt to get the shadow back to it)
- **Power-Up:** Collect the power-up to instantly teleport the shadow back to the player’s position.
- **Game Over:** The game ends if the shadow is detached for more than 5 seconds or if it leaves the visible screen.

## Challenges faced:
- This is my first complete Unity project so there was a lot of trial and error involved as I tried to learn through the process. 
- While implementing jumping logic, to **detect ground**, I was using OnCollisionEnter and looking for the ground layer tag. This led to problems because in some cases the player was landing without exiting collision. **FIX:** I shifted to circle overlap detection where a circle below the player detects the ground by detecting overlap.
- While **detecting landing** to trigger the land animation, I was encountering the same problem so I shifted detection to comparing isGrounded and wasGroundedLastFrame in the update function.
- **Parallax:** I started out with scripting relative movements in background elements to acheive parallax but as the no. of objects increased, it got increasingly complex. Therefore I switched to relying on natural parallax and spacing my sprites in the z axis (which was very time consuming as they had to be scaled to incorporate the new perspective).
- Making the **animator logic** was very challenging as I had to think of all scenarios while making state transition triggers and connecting various animation states(It reminded me of FSM design a lot).
- Upon spamming jump, the animator logic was freezing on Jump. **Fix:** Going from Jump->Idle->Land instead of going Jump->Land->Idle.

## Future Scope:
- The game currently has 3 levels. Although the 3 levels themselves are pretty challenging for first time players which I discovered through peer review, I would like to add more levels and obstacles in the future.
- I would like to explore more types of power ups to make the gameplay even more interesting.


## Credits
Game Design & Development: Snehal Sharma  
Art & Animation design: Snehal Sharma (some images from the internet)  
Art Inspiration: Limbo (Playdead)
