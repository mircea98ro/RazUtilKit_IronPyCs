import wmi

try:
    engine = wmi.WMI()
    q1 = "Select * From Win32_USBControllerDevice"
    for item in engine.query(q1):
        if ("Bluetooth" in item.Dependent.Caption):
            DevID=item.Dependent.DeviceID.split("\\")[1]
            Status=item.Dependent.Status
            print DevID
            print Status
            break
except:
    print "Something didn't work"
