# Jerome's Mission - A Stealth Action Game

Welcome to *Jerome's Mission*, a Unity-based stealth action game where you control Jerome, a young secret agent tasked with infiltrating a high-security complex and shutting down a rogue AI system. Can you help Jerome disable all power sources before time runs out?

---

## Table of Contents
- [Overview](#overview)
- [Gameplay](#gameplay)
- [Controls](#controls)
- [Game Mechanics](#game-mechanics)
- [User Interface](#user-interface)
- [Victory and Defeat Conditions](#victory-and-defeat-conditions)
- [Audio](#audio)
- [Cheat Code](#cheat-code)
- [Installation](#installation)
- [Assets](#assets)

---

### Overview
*Jerome's Mission* places you in the shoes of Jerome, an agent sent by the Ministry of Education to deactivate a powerful AI known as *ChutGPT*. In a race against time, you must navigate a complex, avoid detection by patrolling drones, and disable all power sources to achieve your mission.

---

### Gameplay
In *Jerome's Mission*, players explore a 3D environment from a third-person perspective. Your objective is to deactivate nine power batteries scattered throughout the complex, all while avoiding detection by security drones.

> **Suggested image placement**: Insert an image of the main character, Jerome, and the complex environment.

### Controls
- **Movement**: Use `WASD` to move Jerome. 
  - `W` and `S` to move forward/backward
  - `A` and `D` to rotate left/right
- **Interact**: Press `Space` to deactivate batteries when nearby.

---

### Game Mechanics
#### Batteries
- **Objective**: Locate and disable all nine batteries.
- **Interaction**: When close to a battery, press `Space` to turn it off.
- **Audio and Visual Feedback**: Each battery emits sound when active. The sound stops, and a light above the battery turns off once deactivated.

#### Drones
- **Patrol**: Four drones guard the complex, each following a unique patrol path.
- **Detection**: If Jerome is within 5 units and at a 40-degree angle in front of a drone, he will be rendered unconscious for 5 seconds.
- **Movement**: Drones move along predefined NavMesh paths at a set height.

#### Time Extension Cubes
- Scattered around the complex, these rotating cubes grant Jerome an extra 10 seconds of mission time when collected.
- **Sound Effect**: A sound plays each time Jerome collects a cube.

> **Suggested image placement**: Show a drone and a battery along with a time extension cube.

### User Interface
The game displays:
- **Remaining Time** in `MM:SS` format.
- **Batteries Remaining** to be deactivated.
- **Prompt Message** when Jerome can interact with a battery.

---

### Victory and Defeat Conditions
- **Victory**: Jerome wins when all batteries are disabled. Upon victory, drones are destroyed, and a victory message is displayed.
- **Defeat**: Jerome loses if he runs out of time or is rendered unconscious too many times, with a final message displaying defeat.

> **Suggested image placement**: Include an image of the victory or defeat screen, showcasing the UI elements.

---

### Audio
- **Background Music**: An ambient track plays continuously in the background.
- **Battery Sound**: Each battery emits sound when active.
- **Time Extension Sound**: Plays each time Jerome collects a time cube.

### Cheat Code
Press `Z` during gameplay to activate the cheat mode, which disables drone attacks. Drones will continue patrolling but won’t cause Jerome to lose consciousness.

---

### Installation
1. Clone this repository.
2. Open the project in Unity (tested in Unity version X.X.X).
3. Import required assets from Unity’s Asset Store.
4. Build and run the game.

---

### Assets
The game integrates assets from Unity’s Asset Store, including characters, drones, and environmental props. Please refer to each asset’s individual license for usage terms.

---

Enjoy the challenge, and good luck on your mission to help Jerome thwart ChutGPT!

 
