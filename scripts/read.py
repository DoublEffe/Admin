from pirc522 import RFID
from time import sleep
from pymongo.mongo_client import MongoClient
from pymongo.server_api import ServerApi
uri = "mongodb+srv://fabio:1234@cluster0.bg7sv.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"
# Create a new client and connect to the server
client = MongoClient(uri, server_api=ServerApi('1'))

reader = RFID()
auth_key = [0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF]
print('[press ctrl+c to end the script]')

try:
    while True:
        reader.wait_for_tag()
        error1, tag_type = reader.request()
        if not error1:
            error, uid = reader.anticoll()
            if not error:
                print('UID {}'.format(uid))
                if not reader.select_tag(uid):
                   if not reader.card_auth(reader.auth_a, 4, auth_key , uid):
                    id_hex=reader.read(4)
                    r = reader.read(5)
                    id_s = ''
                    for i in range(0, len(id_hex[1])):
                        if(id_hex[1][i] == 254):
                            break
                        id_s += hex(id_hex[1][i])[2:]
                    mongodb_client = MongoClient(uri)
                    db = mongodb_client['Admin']
                    employee = db['Employee'].find()
                    print(employee[0])
                    print(id_s,r[1][0])
                    reader.stop_crypto() 
           
        sleep(0.1)
                # Scavenging work after the end of the program
except KeyboardInterrupt:
    print('Script end!')
finally:
    reader.cleanup() # Calls GPIO cleanup