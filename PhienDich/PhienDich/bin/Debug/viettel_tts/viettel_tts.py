import json
import requests
import os


url = "https://viettelgroup.ai/voice/api/tts/v1/rest/syn"

# Read file text to get text
f = open("text.txt", "r", encoding="UTF-8")
text_raw = f.read()
text_raw = text_raw.split("\n")
text = ""
for x in text_raw:
    text += (" " + x)
f.close()

#Read file voice.txt to get data
f = open("voice.txt", "r")
voice = f.readline()
f.close()

data = {"text": text, "voice": voice, "id": 2, "without_filter": False, "speed": 0.7, "tts_return_option": 2}
headers = {'Content-type': 'application/json', 'token': 'pVbk1M4oljgpgB-XyMO0sI57l8eRtfp-OcPR4zJJ0NHYE-UK2eBlRdOBfDP1gq1Z'}
response = requests.post(url, data=json.dumps(data), headers=headers, verify=False)

print(response.headers)
# Get status_code.
print(response.status_code)
# Get the response data as a python object.
data = response.content
f = open("output.wav", "wb")
f.write(data)
f.close()
