<template>
  <div class="flex-1">
    <h2 class="text-xl font-semibold mb-4">Kund Information</h2>
    <div class="grid grid-cols-1 lg:grid-cols-2">
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Namn:</span> {{ customer.name }}
        </p>
      </div>
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Email:</span> {{ customer.email }}
        </p>
      </div>
    </div>
    <div class="grid grid-cols-1 lg:grid-cols-2">
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Adress:</span>
          {{ customer.address }}
        </p>
      </div>
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Postnummer:</span>
          {{ customer.zipCode }}
        </p>
      </div>
    </div>
    <div class="grid grid-cols-1 lg:grid-cols-2">
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Stad:</span> {{ customer.city }}
        </p>
      </div>
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Land:</span> {{ customer.country }}
        </p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { Customer } from "~/types";

defineProps<{ customer: Customer }>();
</script>
