# VRcade

VR Hub designed to create space for games related to VRcade project. It aims to allow launching games from one place while being in VR and provide seamless switching between applications.

#Important
Project structure contains file Settings/vrcade.json. To properly use project you need to change `VrcadeInstallPath` to your  ProjectStructure directory location.
For example if you cloned repository to `C:\vrcade` your project structure root will be `C:\vrcade\ProjectStructure`.

#Project Structure
Application will not work fully in Unity Editor, switching between games and hub needs built games to be placed in corresponding directories.
Directory Structure
- ProjectStructure
 - Games
   - Game A
   - Game B
   - [...]
  - Other
 - Hub
 - Settings
   - vrcade.json
  
Each application (hub or game) has to be placed in corresponding directories.
Further information will be added later.
More specific documentation can be found in game code.