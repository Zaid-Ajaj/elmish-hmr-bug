# Elmish HMR Bug

HMR Only works before dispatching messages. After dispatching any message, nothing updates.

# Repro 

```bash
npm install
npm start
```