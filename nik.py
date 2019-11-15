import threading




global dic
dic = []

def hundler (all the socket data):
    global dic
    
    while True:
        data = socketstream.recive()# or however you write it
        while data != "":
            length = int(data[:4])
            new_msg = data[4:length]
            dic.append(new_msg)
            data = data[length+4:]
while True:
    if len(dic) > 0:
        data = dic[0]
        del dic[0]
        break
    
if data == "Login Successful":
            
            
