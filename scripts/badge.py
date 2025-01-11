from fastapi import APIRouter, FastAPI
from fastapi.middleware.cors import CORSMiddleware
import uvicorn
from pydantic import BaseModel
import logging
from pirc522 import RFID
from time import sleep

class Employee(BaseModel):
    id: str
    ruolo: str
    

app = FastAPI()
router = APIRouter()
logger = logging.getLogger("uvicorn.error")
script = "write.py"
auth_key = [0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF]
reader = RFID()

app.add_middleware(
   CORSMiddleware,
   allow_origins = ["http://192.168.178.20"],
   allow_credentials = True,
   allow_methods = ["*"],
   allow_headers = ["*"]
)

@app.get("/")
def read_root():
    return {"hello": "world"}

@app.get("/items/{item_id}")
def read_item(item_id):
    return {"item id": item_id}

@app.post("/")
def save_badge(employee: Employee):
    logger.info(employee.ruolo)
    #with open(script) as file:
        #exec(file.read())
    try:
        while True:
            reader.wait_for_tag()
            error, tag_type = reader.request()
            print(error)
            if not error:
                error, uid = reader.anticoll()
                if not error:
                    print('UID {}'.format(uid))
                    if not reader.select_tag(uid):
                       if not reader.card_auth(reader.auth_a, 4, auth_key , uid):
                        s = 0
                        l = []
                        while s < len(employee.id):
                            #print(id[s:s+2])
                            i = int(employee.id[s:s+2],16)
    
                            h = hex(i)
                            l.append(i)
                            s = s +2
                    
                        
                        error_w = reader.write(4,l+ [-1-1] * (16 -len(l)))
                        if not error_w:
                            if not reader.card_auth(reader.auth_a, 5, auth_key , uid):
                                if(employee.ruolo == 'Tecnico'):
                                    r = [0x02]
                                    error_w = reader.write(5,r+ [-1-1] * (16 -len(r)))
                                    if not error_w:
                                        
                                        id1 = reader.read(4)
                                        id2 = reader.read(5)
                                        print(id1[1],id2[1])
                                        break
                                elif(employee.ruolo == 'Dipendente'):
                                    r = [0x03]
                                    error_w = reader.write(5,r+ [-1-1] * (16 -len(r)))
                                    if not error_w:
                                        
                                        id1 = reader.read(4)
                                        id2 = reader.read(5)
                                        print(id1[1],id2[1])
                                        break
                                elif(employee.ruolo == 'Dirigente'):
                                    r = [0x01]
                                    error_w = reader.write(5, r + [-1-1] * (16- len(r)))
                                    if not error_w:
                                        
                                        id1 = reader.read(4)
                                        id2 = reader.read(5)
                                        print(id1[1],id2[1])
                                        break
                        
                        
                        
                        
                        
                        
                        
                        print('error')
                        reader.stop_crypto() 
               
            sleep(0.1)
                # Scavenging work after the end of the program
    except KeyboardInterrupt:
        print('Script end!')
    finally:
        reader.cleanup()
    return {"message":"test"}

#@router.post("/")
#def save_badge(employee: Employee):
#    return employee
#app.include_router(router)

#uvicorn.run("badge:app", host="0.0.0.0",port="8000")