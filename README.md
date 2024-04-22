## API
Send a socket request with parameters to the server's ip address and port.

Params:
```
T - target of the request
С - command key
P - auth token
```

Example (Dart):
```dart
import 'dart:io';

static const target = "MPC";
static const command = 921;
static const server_ip = "192.168.0.1";
static const server_port = 1337;
static const auth_token = '12345678';

Future<void> sendCommand() async {
  final request = 'T=$target&C=$command&P=$auth_token';
  Socket socket = await Socket.connect(server_ip, server_port);
  socket.writeln(request);
  await socket.flush();
}
```

## List of targets
```
MPC
... will be supplemented later ...
```

## List of MPC-HC command keys
<details>
  <summary>Expand</summary>
<br>
  
```
800 - Open File
801 - Open DVD
802 - Open Device
804 - Close
805 - Save As
806 - Save Image
807 - Save Image (auto)
808 - Save thumbnails
809 - Load Subtitle
810 - Save Subtitle
814 - Properties
816 - Exit
817 - Toggle Caption&Menu
818 - Toggle Seeker
819 - Toggle Controls
820 - Toggle Information
821 - Toggle Statistics
822 - Toggle Status
823 - Toggle Subresync Bar
824 - Toggle Playlist Bar
825 - Toggle Capture Bar
826 - Toggle Shader Editor Bar
827 - View Minimal
828 - View Compact
829 - View Normal
830 - Fullscreen
831 - Fullscreen (w/o res.change)
832 - Zoom 50`%
833 - Zoom 100`%
834 - Zoom 200`%
835 - VidFrm Half
836 - VidFrm Normal
837 - VidFrm Double
838 - VidFrm Stretch
839 - VidFrm Inside
840 - VidFrm Outside
860 - Next AR Preset
861 - PnS Reset
862 - PnS Inc Size
863 - PnS Dec Size
864 - PnS Inc Width
865 - PnS Dec Width
866 - PnS Inc Height
867 - PnS Dec Height
868 - PnS Left
869 - PnS Right
870 - PnS Up
871 - PnS Down
872 - PnS Up/Left
873 - PnS Up/Right
874 - PnS Down/Left
875 - PnS Down/Right
876 - PnS Center
877 - PnS Rotate X+
878 - PnS Rotate X-
879 - PnS Rotate Y+
880 - PnS Rotate Y-
881 - PnS Rotate Z+
882 - PnS Rotate Z-
884 - Always On Top
886 - Options
887 - Play
888 - Pause
889 - Play/Pause
890 - Stop
891 - Framestep
892 - Framestep back
893 - Go To
894 - Decrease Rate
895 - Increase Rate
896 - Reset Rate
897 - Jump Backward (keyframe)
898 - Jump Forward (keyframe)
899 - Jump Backward (small)
900 - Jump Forward (small)
901 - Jump Backward (medium)
902 - Jump Forward (medium)
903 - Jump Backward (large)
904 - Jump Forward (large)
905 - Audio Delay +10ms
906 - Audio Delay -10ms
907 - Volume Up
908 - Volume Down
909 - Volume Mute
918 - Previous Playlist Item
919 - Next Playlist Item
920 - Previous
921 - Next
922 - DVD Title Menu
923 - DVD Root Menu
924 - DVD Subtitle Menu
925 - DVD Audio Menu
926 - DVD Angle Menu
927 - DVD Chapter Menu
928 - DVD Menu Left
929 - DVD Menu Right
930 - DVD Menu Up
931 - DVD Menu Down
932 - DVD Menu Activate
933 - DVD Menu Back
934 - DVD Menu Leave
943 - Boss key
948 - Player Menu (short)
949 - Player Menu (long)
950 - Filters Menu
951 - Next Audio
952 - Prev Audio
953 - Next Subtitle
954 - Prev Subtitle
955 - On/Off Subtitle
956 - Next Audio (OGM)
957 - Prev Audio (OGM)
958 - Next Subtitle (OGM)
959 - Prev Subtitle (OGM)
960 - Next Angle (DVD)
961 - Prev Angle (DVD)
962 - Next Audio (DVD)
963 - Prev Audio (DVD)
964 - Next Subtitle (DVD)
965 - Prev Subtitle (DVD)
966 - On/Off Subtitle (DVD)
967 - Zoom Auto Fit
969 - Volume boost increase
970 - Volume boost decrease
971 - Volume boost Min
972 - Volume boost Max
2302 - Reload Subtitles
24000 - Subtitle Delay -
24001 - Subtitle Delay +
32769 - Tearing Test
32770 - Toggle Pixel Shader
32778 - Remaining Time
32779 - Toggle Direct3D fullscreen
32780 - Goto Prev Subtitle
32781 - Goto Next Subtitle
32782 - Shift Subtitle Left
32783 - Shift Subtitle Right
32784 - Display Stats
```
</details>
