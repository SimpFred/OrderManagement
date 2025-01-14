<template>
  <div class="flex-1">
    <h2 class="text-xl font-semibold mb-4">Kund Information</h2>
    <div class="flex flex-col md:flex-row md:space-x-4 md:gap-auto">
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Namn:</span> {{ order.customer.name }}
        </p>
      </div>
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Email:</span> {{ order.customer.email }}
        </p>
      </div>
    </div>
    <div class="flex flex-col md:flex-row md:space-x-4 md:gap-auto">
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Adress:</span>
          {{ order.customer.address }}
        </p>
      </div>
      <div class="mb-2">
        <p class="text-gray-800">
          <span class="font-semibold">Postnummer:</span>
          {{ order.customer.zipCode }}
        </p>
      </div>
    </div>
    <div>
      <p class="text-gray-800">
        <span class="font-semibold">Land:</span> {{ order.customer.country }}
      </p>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { Order } from "~/types";

const props = defineProps<{ order: Order }>();
</script>
