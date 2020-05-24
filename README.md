# Halo-Space-Battle

This project is a recreation of the Long Night of Solace space battle seen in Halo: Reach. The project uses autonomous AI bots (both friendly and enemy) which implement a number of steering behaviours including Seek, Arrive and Pursue allowing for one entity to track and fly towards another entity.

The enemy bots spawn at a few pre determined locations, handled by the Spawner script (written by me). The bots can then choose randomly from a path of waypoints to fly towards, choosing another waypoint when the destination is reached (Waypoint script, also written by me).

The friendly AI, which the camera tracks, is controlled by the SabreAI (written by me) and BigBoid scripts. The SabreAI script chooses an enemy to focus on while prompting a seek behaviour in the BigBoid script. The sabre can destroy an enemy by getting close enough to where it's Collider intercepts an enemy Collider, which will destroy the enemy. The SabreAI script also determines when to fly back to the UNSC Savannah after all of the enemies have been destroyed.

The CamMove script (written by me) simply deals with the establishing shot at the start of the scene as well as switching the camera view to the Sabre before the action starts.
