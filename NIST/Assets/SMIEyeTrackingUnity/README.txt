Collected variables and their descriptions from EyeTracker.cs ("_eye" output data files)

Column A: BinocPorX returns the latest available binocular point of regard (POR) for the device
Column B: BinocPorY returns the latest available binocular point of regard (POR) for the device
Column C: LeftPorX returns the latest available left eye point of regard (POR) for the device
Column D: LeftPorY returns the latest available left eye point of regard (POR) for the device
Column E: RightPorX returns the latest available right eye point of regard (POR) for the device
Column F: RightPorY returns the latest available right eye point of regard (POR) for the device
Column G: IPD returns the latest available Interpupillary distance (IPD) [m]
Column H: LeftGazeBaseX returns the latest available gaze base point (eye ball center) for the left eye [m]
Column I: LeftGazeBaseY returns the latest available gaze base point (eye ball center) for the left eye [m]
Column J: LeftGazeBaseZ returns the latest available gaze base point (eye ball center) for the left eye [m]
Column K: RightGazeBaseX returns the latest available gaze base point (eye ball center) for the right eye [m]
Column L: RightGazeBaseY returns the latest available gaze base point (eye ball center) for the right eye [m]
Column M: RightGazeBaseZ returns the latest available gaze base point (eye ball center) for the right eye [m]
Column N: LPupilRadius returns the last available pupil radius of the left eye [m]
Column O: RPupilRadius returns the last available pupil radius of the right eye [m]
Column P: LGazeDirX returns the latest available left 3D gaze direction for the left eye
Column Q: LGazeDirY returns the latest available left 3D gaze direction for the left eye
Column R: LGazeDirZ returns the latest available left 3D gaze direction for the left eye
Column S: RGazeDirX returns the latest available right 3D gaze direction for the right eye
Column T: RGazeDirY returns the latest available right 3D gaze direction for the right eye
Column U: RGazeDirZ returns the latest available right 3D gaze direction for the right eye
Column V: MS 
Column W: Time


smi_GetBinocularPor().x
smi_GetBinocularPor().y
smi_GetLeftPor().x
smi_GetLeftPor().y
smi_GetRightPor().x
smi_GetRightPor().y
smi_GetIPD()
smi_GetLeftGazeBase().x
smi_GetLeftGazeBase().y
smi_GetLeftGazeBase().z
smi_GetRightGazeBase().x
smi_GetRightGazeBase().y
smi_GetRightGazeBase().z
smi_GetLeftPupilRadius()
smi_GetRightPupilRadius()
smi_GetLeftGazeDirection().x
smi_GetLeftGazeDirection().y
smi_GetLeftGazeDirection().z
smi_GetRightGazeDirection().x
smi_GetRightGazeDirection().y
smi_GetRightGazeDirection().z
timestamp
timestamptoa


Collected variables and their descriptions from EyeTracker.cs ("_vr" output data files)

Roll | Pitch | Yaw | MS | Time | X | Y | Z

VRRot = getrot();
VRPos = getpos();

(VRRot.x + 180) % 360   roll
(VRRot.y + 180) % 360   pitch
(VRRot.z + 180) % 360   yaw
timestamp MS
timestamptoa Time 
VRPos.x  X
VRPos.y  Y
VRPos.z  Z


