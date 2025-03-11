"use client";

import { useDisclosure } from "@mantine/hooks";
import { Modal, Button, TextInput, Stack, Group } from "@mantine/core";
import { useState } from "react";
import { Client } from "../types/client";
import { NewClient } from "../types/newClient";

export default function CreateClientForm(){
  const [opened, {open, close}] = useDisclosure(false);
  const [formData, setFormData] = useState<NewClient>({name: "", address: "", contactEmail: "", contactPhone: ""});


  const handleChange = (field: keyof Client) => (e: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [field]: e.target.value });
  };

  const createClient = async () => {
    try{
    console.log(formData);
      const response = await fetch("https://localhost:7249/api/Client", {
        method: "POST",
        headers:{
          "Content-Type": "application/json"
        },
        body: JSON.stringify(formData)
      });
      if (!response.ok){
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      console.log("Client created succesfully")
      close()
    } catch (error){
      console.error("Error creating client", error);
    }
  }

  return(
  <div className="flex justify-center items-center h-screen">
    <Button onClick={open} className="bg-blue-500 hover:bg-blue-600">
      Create Client
    </Button>

    <Modal opened={opened} onClose={close} title="Create Client" centered>
      <Stack>
        <TextInput 
          label="Name"
          placeholder="Name of the client"
          value={formData?.name}
          onChange={handleChange("name")}
        />
        <TextInput 
          label="Address"
          placeholder="Address of the client"
          value={formData?.address}
          onChange={handleChange("address")}
        />
        <TextInput 
          label="Email"
          placeholder="Email of the client"
          value={formData?.contactEmail}
          onChange={handleChange("contactEmail")}
        />
        <TextInput 
          label="Phone number"
          placeholder="Phone number of the client"
          value={formData?.contactPhone}
          onChange={handleChange("contactPhone")}
        />
      </Stack>
      <Group mt="md">
          <Button className="bg-blue-500 hover:bg-blue-600" onClick={createClient}>
            Create
          </Button>
          <Button className="bg-gray-500 hover:bg-gray-600" onClick={close}>
            Cancel
          </Button>
        </Group>
    </Modal>
  </div>)
}