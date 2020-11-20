import requests, os, json

model_id = '98d753c0-3466-4eff-a7a5-c60ec466caab'
api_key = 'z-YHZH2s1ANZi4adh9_lUfNGt1P9joCu'

url = 'https://app.nanonets.com/api/v2/ObjectDetection/Model/' + model_id

response = requests.request('GET', url, auth=requests.auth.HTTPBasicAuth(api_key,''))

state = json.loads(response.text)["state"]
status = json.loads(response.text)["status"]

if state != 5:
	print("The model isn't ready yet, it's status is:", status)
	print("We will send you an email when the model is ready. If your imapatient, run this script again in 10 minutes to check.")
	modelState = "Retraining"
else:
	print("NEXT RUN: python ./code/prediction.py ./images/88.jpg")
	modelState = "Ready"

f = open("state.txt", "w")
f.write(modelState)
f.close()
